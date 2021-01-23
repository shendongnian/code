    private void addmemberbutton_Click(object sender, RoutedEventArgs e)
    {
       foreach(Member m in memberlist)
       {
          puptextbox.Text = m.memberaddress;
          /*memberlist.Add(j);*/
          lstadd.Items.Add(m);
       }
    
    }
