       public class YourModel 
       { 
          public Chart GenerateChart()
          {
             Chart chart = new Chart();
            //place code to set up the chat, i.e. Axis, BackColors...etc
          }
       }
    
       public class YourPresenter
       {
         IView _view;
         public YourPresenter(IView view)
         {
             _view = view;
         }
    
         public void GetChart()
         {
            YourModel model = new YourModel();
            _view.ChartControl = model.GenerateChart();
         }
       }
    
       public partial class _Default : System.Web.UI.Page,IView 
       {
         protected void Page_Load(object sender, EventArgs e)
         {
         }
         protected void ButtonResult_Click(object sender, EventArgs e)
         {
            YourPresenter presenter = new YourPresenter(this);
            presenter.GetChart();
         }
    
         public Chart ChartControl
         {
            get{return "a placeHolder where your chart is displayed";}
            set{"a placceHolder where your chart will be displayed" = value;}
         }
       }
       public interface IView
       {
         Chart ChartControl { get; set;}
       }
