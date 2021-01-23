	public class ChangeableSource : UITableViewSource
	{
		public bool Grouped { get; set; }
		public override int NumberOfSections(UITableView tableView)
		{
			if(Grouped)
			{
				return 4;
			}
			else
			{
				return 1;
			}
		}
		public override int RowsInSection(UITableView tableview, int section)
		{
			return 3;
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("Default");
			if(cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, "Default");
			}
			cell.TextLabel.Text = String.Format("IndexPath {0} {1}", indexPath.Section, indexPath.Row);
			return cell;
		}
	}
	public class ToggleTableView : UIView
	{
		UITableView ungroupedView;
		UITableView groupedView;
		ChangeableSource changeableSource;
		public void SetStyle(bool grouped)
		{
			changeableSource.Grouped = grouped;
			if(changeableSource.Grouped)
			{
				ungroupedView.RemoveFromSuperview();
				AddSubview(groupedView);
			}
			else
			{
				groupedView.RemoveFromSuperview();
				AddSubview(ungroupedView);
			}
		}
		public bool GetStyle()
		{
			return changeableSource.Grouped;
		}
		public ToggleTableView()
		{
			var btn = new UIButton(new RectangleF(10, 10, 150, 40));
			btn.SetTitle("Change", UIControlState.Normal);
			btn.TouchUpInside += (s,e) => ToggleStyle(this, new EventArgs());
			var tvFrame = new RectangleF(0, 60, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 60);
			ungroupedView = new UITableView(tvFrame, UITableViewStyle.Plain);
			groupedView = new UITableView(tvFrame, UITableViewStyle.Grouped);
			AddSubview(btn);
			AddSubview(ungroupedView);
			changeableSource = new ChangeableSource();
			changeableSource.Grouped = false;
			ungroupedView.Source = changeableSource;
			groupedView.Source = changeableSource;
		}
		public event EventHandler<EventArgs> ToggleStyle = delegate {};
	}
	public class TogglingTableController : UIViewController
	{
		public TogglingTableController() : base ()
		{
		}
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var view = new ToggleTableView();
			view.ToggleStyle += (s,e) => 
			{
				view.SetStyle(! view.GetStyle());
			};
		
			this.View = view;
		}
	}
	[Register ("AppDelegate")]
	public  class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		TogglingTableController viewController;
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			viewController = new TogglingTableController();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
	public class Application
	{
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
