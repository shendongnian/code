    public class ViewModel{
       private ImageSource _sharedImage;
       public ImageSource SharedImage{
          get{
             if(_sharedImage== null){
                      // Go load the image from somewhere
             }
             return _sharedImage;
          }
          set{
             if(_sharedImage == null){
                  // Store the image contained in value into your local cache
             }
              _sharedImage = value;
          }
       }
    }
