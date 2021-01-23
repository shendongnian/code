    		using System.Windows;
		using System.Windows.Controls;
		using System.Windows.Controls.Primitives;
		using System.Windows.Media;
		namespace SelectDataGridCell
		{
			public partial class MainWindow : Window
			{
				public MainWindow()
				{
					this.InitializeComponent();
				}
				private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
				{
					DataGridCell cell = GetCell(1, 1, myDataGrid);
							cell.Background = new SolidColorBrush(Colors.Red);
				}
				public DataGridCell GetCell(int rowIndex, int columnIndex, DataGrid dg)
				{
					DataGridRow row = dg.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
					DataGridCellsPresenter p = GetVisualChild<DataGridCellsPresenter>(row);
					DataGridCell cell = p.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
					return cell;
				}
				static T GetVisualChild<T>(Visual parent) where T : Visual
				{
					T child = default(T);
					int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
					for (int i = 0; i < numVisuals; i++)
					{
						Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
						child = v as T;
						if (child == null)
						{
							child = GetVisualChild<T>(v);
						}
						if (child != null)
						{
							break;
						}
					}
					return child;
				} 
			}
		}
