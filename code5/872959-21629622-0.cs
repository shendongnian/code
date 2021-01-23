    public partial class MainPage : PhoneApplicationPage
        {
            PhoneNumberChooserTask phNumChoseTask;
            bool but1Clicked = false;
            bool but2Clicked = false;
            public MainPage()
            {
                InitializeComponent();
                phNumChoseTask = new PhoneNumberChooserTask();
                phNumChoseTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            }
    
            void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
            {
                if (e.TaskResult == TaskResult.OK){
                   if(but1Clicked)
                       PersonNo1.Text = e.PhoneNumber;  //Add number to Person1 textbox
                   else
                       PersonNo2.Text = e.PhoneNumber;  //Add number to Person2 textbox
                }
                //How I can modify to add Person2 number to textbox
                but1Clicked = false;
                but2Clicked = false;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                
                but1Clicked = true;
                phNumChoseTask.Show();
            }
    
            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                MessageBox.Show("Text Chsng");
            }
    
            private void Button1_Click(object sender, RoutedEventArgs e)
            {
                but2Clicked = true;
                //I'm able to use the same object to show but not add to Person2
                phNumChoseTask.Show();
            }
        }
