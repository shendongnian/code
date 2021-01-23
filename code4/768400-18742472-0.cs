    private List<string> questions= new List<string>()
        {"welcome to question 2", "welcome to question 3", "welcome to question 4"};
    int a= 0;
    public void Click_AppBar(object sender, System.EventArgs e)
    {
        
            if (RadioA.IsChecked == true && a==0
                     ||RadioB.IsChecked == true && a==1
                     ||RadioC.IsChecked == true && a==2)
            {
                textBlock1.Text =questions[a];
                a++;
            }
            else if (RadioD.IsChecked == true && a==3){
                a++;
                MessageBox.Show("You have finished");
            }
            ShowResult.Text = (a.ToString());
    }
