        class FileTextBox : System.Windows.Form.TextBox{
           //===>This enumeration is more readable insted of a string XD
           public enum DialogType{
             File,Folder
           }
         //===>This property we will handle what kind of Dialog to show
        public DialogType OpenDialogType{
          get;
          set;
        }
        
        //===>This is where Object Oriented Programming a& Design do his magic
        public System.Windows.Forms.DialogResult ShowDialog(string Title =""){
          //===>This function is where we define what kind of dialog  to show
          System.Windows.Forms.DialogResult Result =   System.Windows.Forms.DialogResult.None ;
          object Browser=null;
    
               switch(this.OpenDialogType){
                      case DialogType.File:
                      Browser = new OpenFileDialog();
                      ((Browser)OpenFileDialog).Title= Title;
                       if(this.Text.Trim() !="" && this.Text != null ){
                         ((Browser)OpenFileDialog).FileName = this.Tex;
                       }
                      Result = ((Browser)OpenFileDialog).ShowDialog();
    
                      break;
    
                      case DialogType.Folder:
                      Browser = new FolderBrowserDialog ();
                      ((Browser)FolderBrowserDialog).Description = Title;
    
                      if(this.Text.Trim() !="" && this.Text != null ){
                          ((Browser)FolderBrowserDialog).RootFolder = this.Text; 
                      } 
                                       
                      Result = ((Browser)FolderBrowserDialog).ShowDialog();
                      break;
               }
        return Result;//===>We return thi dialog result just if we want to do something else
        }
    
    }
    /*
    Create a class and copy/paste this code, I think is going to work because
    I didn't compiled then go to ToolBox window find this control and Drag & Drop
    to your WinForm and in the property window find OpenDialogType property
    and this is where you kind define the behavior of OpenDialog();
    
    I'm currently working in a little project in Vs where I create a custom
    UI Control downloaded from my git repository 
