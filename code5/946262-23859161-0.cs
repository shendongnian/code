    public void BindingMethod(int index)
    {
     DataList1.SelectedIndex = index;
                if (e.CommandName.Equals("MID"))
                {
         AnswerId = Convert.ToInt32(DataList1.DataKeys[index].ToString());// a global variable
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    var memos = (from m in db.Memos
                                 where m.memoId == AnswerId
                                 select m).First();
                       legendtitle.InnerText = memos.title.ToString();
                    TextBox2.Text = memos.description.ToString(); 
    }
