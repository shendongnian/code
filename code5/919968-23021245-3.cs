    foreach(string element in ids)
    {
       int id = Int32.Parse(element);
       ListViewItem item = new ListViewItem(name[id]);
       item.SubItems.Add(ip[id]);
       Ping pingsv = new Ping();
       pingsv.PingCompleted += pingsv_PingCompleted;
       pingsv.SendAsync(IPAddress, 500, id);
       
    }
    [... somewhere else in the same class ...]
    void pingsv_PingCompleted(object sender, PingCompletedEventArgs e)
    {
          long pingtime = e.Reply.RoundtripTime;
          // do something with pingtime...
          // id has been saved to UserState (see above)
          string id = (string)e.UserState;
          // do something with id...
    }
