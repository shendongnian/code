    //should add this using at the beginning
    using System.Runtime.InteropServices;
    [DllImport("user32")]
    private static extern int MapVirtualKey(int ucode, int mapType);
    //The KeyUp event handler for your RichTextBox
    private void keyUp_Handler(object sender, KeyEventArgs e){
      if (char.IsControl((char) MapVirtualKey(KeyInterop.VirtualKeyFromKey(e.Key),0x2)))
         UpdateContainingBlockState();
    }
    //The PreviewMouseUp event handler for your RichTextBox
    private void previewMouseUp_Handler(object sender, MouseButtonEventArgs e){
      UpdateContainingBlockState();
    }
    //The GotKeyboardFocus event handler for your RichTextBox
    private void gotKeyboardFocus_Handler(object sender, 
                                          KeyboardFocusChangedEventArgs e){
      UpdateContainingBlockState();
    }
