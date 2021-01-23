    public partial class tbIndexUI : System.Web.UI.UserControl
    {
        public int numColumns
        {
            set
            {
                ViewState["numOfCols"] = value;
            }
        }
    
        public int itemsPerColumn
        {
            set
            {
                ViewState["itemsPerCol"] = value;
            }
        }
        public static void passData(int numOfCol, int itemsPerCol)
        {
            numColumns = numOfCol;
            itemsPerColumn = itemsPerCol;
        }
        //when you need to use the stored values
        int _numOfCols = ViewState["numOfCols"] ;
        int itemsPerCol = ViewState["itemsPerCol"] ;
     }
