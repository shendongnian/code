    public class CodeBehindClass
    {
       private ObservableCollection<MyGrid> gride;
       public CodeBehindClass()
       {
          gride = new ObservableCollection<MyGrid>();
          dataGridView1.ItemsSource = gride;
       }
       
       private void ButtonHandler(object sender, RoutedEventArgs e)
       {
          var myg1 = new MyGrid(textBox10.Text, textBox11.Text, textBox12.Text);
          gride.Add(myg1);
       }
    }
