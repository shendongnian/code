    public void delete()
    {
      foreach (var x in Queue.ToList())
      {
          if (x.IsSelected)
          {
              Queue.Remove(x);
          }
      }
    }
