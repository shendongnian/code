    dataGridView1.Columns.Add(new DataGridViewRatingColumn(){
         //init some properties here ...
     });
    //To change the ReadOnly which allows user to rate or not, you have to cast
    //the column to DataGridViewRatingColumn first, this behavior is caused by 
    //the failing/abnormal behavior of overriding the ReadOnly (I had to use new instead).
    ((DataGridViewRatingColumn)dataGridView1.Columns[0]).ReadOnly = true; (default by false)
    //You should also enable DoubleBuffered on your DataGridView to eliminate flicker
    typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | 
                                                  System.Reflection.BindingFlags.NonPublic)
                   .SetValue(dataGridView1, true, null);
