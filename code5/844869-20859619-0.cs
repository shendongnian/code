    public class MyForm
    {
       private bool _disableEvents = false;
       private void Event1(object sender, EventArgs e)
       {
          if (_disableEvents)
             return;
          _disableEvents = true;
          try
          {
             // do stuff that triggers Event2
          }
          finally
          {
             _disableEvents = false;
          }
       }
       private void Event2(object sender, EventArgs e)
       {
          if (_disableEvents)
             return;
          _disableEvents = true;
          try
          {
             // do stuff that triggers Event1
          }
          finally
          {
             _disableEvents = false;
          }
       }
    }
