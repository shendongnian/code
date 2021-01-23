    public class customTextbox:TextBox
    {
       public customTextbox():base()
       {
           this.AcceptsReturn = true;
           this.AllowDrop = true;
           this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
           //set your remaining propreties
           this.PreviewDragEnter +=customTextbox_PreviewDragEnter;
           this.PreviewDragLeave +=customTextbox_PreviewDragLeave;
           this.SelectionChanged += customTextbox_SelectionChanged;         
       }
       void customTextbox_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
       {
           //code here
       }
       private void customTextbox_PreviewDragLeave(object sender, System.Windows.DragEventArgs e)
       {
           //code here
       }
       private void customTextbox_PreviewDragEnter(object sender, System.Windows.DragEventArgs e)
       {
          //code here 
       }     
    }
