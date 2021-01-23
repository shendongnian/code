    Queue<char> _buffer = new Queue<char>();
    
    private void User_KeyPress(object sender, KeyPressEventArgs e)
    {
      _buffer.Enqueue(e.KeyChar);
    
      if(_buffer.Count > 5)
      {
        StringBuilder sb = new StringBuilder("You Wrote: ");
        while(_buffer.Count > 0)
          sb.AppendFormat(" {0}", _buffer.Dequeue());
    
        Console.WriteLine(sb.ToString());
      }
    }
