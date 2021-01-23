    using System.Linq;
    //First Lets create this property, it should return the selected EnemyTabUserControl inside the tabControl
    public EnemyTabUserControl CurrentTab {
        get { 
             return tabControl1.SelectedTab.Controls.OfType<EnemyTabUserControl>().First();
        }
    }
    // then if we make the textbox you want to reference from outside the code we can do this
    CurrentTab.NameOfTheTextBox;
