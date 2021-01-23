     public class DragDropListBox : ListBox
     {
	    private static DateTime mousePressedTime;
	
	    public DragDropListBox()
	    {
		  this.PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDownHandler;
		  this.PreviewMouseLeftButtonUp   += PreviewMouseLeftButtonUpHandler;
	    }
 
	    private void PreviewMouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
	    {
		  mousePressedTime    = DateTime.Now;
	    }
 
	    private void PreviewMouseLeftButtonUpHandler(object sender, MouseButtonEventArgs e)
	    {
		  TimeSpan difference = DateTime.Now - mousePressedTime;
		  if (difference.TotalSeconds <= 1)
		  {
			// short press
			if (SelectedItem != null)
			{
				// do what ever you have to
			}
		  }
		  UnselectAll();
	    }
     }
