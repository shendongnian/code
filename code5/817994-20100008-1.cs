    public class MyTable //Side comment: revise your naming conventions, this is not a table.
    {
       private bool _isOccupied;
       public bool IsOccupied
       {
           get { return _isOccupied; }
           set
           {
               _isOccupied = value;
               NotifyPropertyChange("IsOccupied");
           }
        }
        //.. Other members here..
    }
