    private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (e.KeyChar)
      {
        //allowed keys 1-6 + backspace and delete + arrowkeys
        case (char)Keys.Back:
        case (char)Keys.Delete:
        case (char)Keys.D0:
        case (char)Keys.D1:
        case (char)Keys.D2:
        case (char)Keys.D3:
        case (char)Keys.D4:
        case (char)Keys.D5:
        case (char)Keys.D6:
        case (char)Keys.Left:
        case (char)Keys.Up:
        case (char)Keys.Down:
        case (char)Keys.Right:
            break;
        default:
            e.Handled = true;
            break;
      }
    }
