    partial class MainWindow : Window
    {
         List<someImageClass> images;// <------this here 
         /*someImageClass should store the paths to the images */
         string currentimage; //maintain this or if you are binding to listbox or other list control
                              //you will be able to use ((someImageClass) listcontrol.selectedItem).path
         private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
         {
              //so in here you can
              if(!File.Exists(currentimage.path))
              {
                  /*show dialog*/ 
                  
              }
              else
              {
                using(FileStream fs = new FileStream(currentimage.path,FileMode.CreateNew,FileAccess.ReadWrite))
                using(BinaryWriter bw = new BinaryWriter(bw))
                         {
                                   bw.WriteByte();//loop this images are not 1 byte
                                  /*you don't really need binarywriter it will depend on what you 
                                   are using to store the image data. some types have 
  
                                   built in save functions*/
                         }
               }
             .....
         }
         
    }
