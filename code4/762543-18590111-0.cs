    var isDone = false;
    while(!isDone) {
        try {
            // code
            isDone = true;
        }
        catch(Exception ex) {
          if (ex.Message.Substring(1, 5) == "error")
          {
            continue; // shortcuts it back to the beginning of the while loop
          }
          // other exception handling
          isDone = true;
        }
    }
