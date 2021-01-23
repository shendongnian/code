     protected void SelectID(){
                //Just a dummy value to store the matched item
                int indexOfMatchedItem=0;
                //This is the true essential part!!!
                //I intiatl as -1 as we are using index which start from -1 then increase ...1,2,3
                int index=-1;
                
                //Seen I'm using Listview DataContext bound with database.
                foreach (DataRow dtrCurrentRow in (((System.Data.DataView)CategoriesListView.ItemsSource)).Table.Rows)
                {
                    //Retrieve the value frm the particula column:
                    String value = dtrCurrentRow[0].ToString().TrimEnd();
                    //MessageBox.Show("" + value);
                    
                    //Increase every time in counter a row:
                    index++;
                    //Match whether it is true or what:
                    //Example: "C0001" equals "C0002":Will Not enter
                    //Example: "C0002" equals "C0002":Will Enter
                    if (value.Equals(Last_CID))
                    {
                        //I can enter here already:
    
                             //The "Index" value with specific row index will be initial to the dummy "indexOfMatchedItem"                    
                             indexOfMatchedItem = index;
                             //MessageBox.Show("" + indexOfMatchedItem);
                             break;
               
                    }
                }
                //When the dummpy position is equals to the current index postion in the list:Enter below code:
                //Example: 1 == 1
                if (indexOfMatchedItem == index)
                {
                    CategoriesListView.SelectedItems.Clear();
                    CategoriesListView.SelectedIndex = indexOfMatchedItem;
                }   
                     
                }
        
