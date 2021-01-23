    while (true)
    {
        byte[] data = new byte[1024];
        var received = client.Receive(data);
        if(received > 0)
        { //careful, how do you know you have it all?
          PaintObject a = (PaintObject)DeserializeData(data);
          ShapeList.Add(a);
          Invalidate();
        }
        if(!queue.IsEmpty)
        {
           //queue dequeue and send
           client.Send(...);
        }
    }
