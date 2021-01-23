    bool suppressEnter = false;
    //Here is the Enter event handler used for all the DateTimePicker yours
    private void dateTimePickers_Enter(object sender, EventArgs e){
      if (suppressEnter) return;
      DateTimePicker picker = sender as DateTimePicker;
      picker.Hide();
      typeof(DateTimePicker).GetMethod("RecreateHandle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(picker, null);
      picker.Show();
      suppressEnter = true;
      picker.Focus();
      suppressEnter = false;
    }
