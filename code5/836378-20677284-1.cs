    KeyboardState now = Keyboard.GetState();
    if (now.IsKeyUp(Keys.E) && oldState.IsKeyDown(Keys.E))
    // i.e. a "release event"
    {
      if (form.Visible)
      {
       form.Hide();
      } 
     else 
    {
      form.Show();
    }
}
    oldState = now;
