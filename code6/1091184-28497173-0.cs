        public class YourClass
        {
             // The other class would register to this event 
             public event Action<string[]> TextBoxDropDown;
            
             public void DragDropRichTextBox_DragDrop(
                object sender,DragEventArgs e)
             { 
                string[] fileNames = e.Data.GetData(DataFormats.FileDrop) 
                                       as string[];
                if (fileNames != null&&TextBoxDropDown !=null)
                 {
                     TextBoxDropDown(fileNames);    
                 }
             }
        }
   
 
