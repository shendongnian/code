    foreach (WCore.CategoryFields cat in Global.getCategories()){
        ListBoxItem c = new ListBoxItem;
        c.Text = cat.CategoryId;
        c.Tag = cat.CategoryName;
        if (ints != null)
        {
            if (ints.Contains(c.Tag))
               Invoke(new Action(()=>checkedListBox1.Items.Add(c, true)));
            else
               Invoke(new Action(()=>checkedListBox1.Items.Add(c, false)));
        }
        else
            Invoke(new Action(()=>checkedListBox1.Items.Add(c, false)));
    }
    //Add this class somewhere in your form class or beside it
    public class ListBoxItem {
       public string Text {get;set;}
       public object Tag {get;set;}
       public override string ToString(){
          return Text;
       }
    }
