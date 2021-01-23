    void ShowCommunication(int[][] communication, int[] suspects)
      {
          var table = new Dictionary<int, Suspect>();
          // We are going through everyone, though 
          // communication.Where(t => suspects.Contains(t[0]) || suspects.Contains(t[1]))        
          // could speed it up, although that leaves us with an incomplete graph
          foreach (var chat in communication)
          {
              if (!table.ContainsKey(chat[0])) table[chat[0]] = new Suspect(chat[0]);
              if (!table.ContainsKey(chat[1])) table[chat[1]] = new Suspect(chat[1]);
      
              // Remove the if-statement if you want the communication in order
              if (!table[chat[0]].CoSuspects.Contains(table[chat[1]]))
              {
                table[chat[0]].CoSuspects.Add(table[chat[1]]);
                table[chat[1]].CoSuspects.Add(table[chat[0]]);
              }
          }
      
          Console.WriteLine("All members");
          foreach (var key in table)
          {
              Console.WriteLine("{0} talked to {1}", key.Key, string.Join(", ", key.Value.CoSuspects.Select(t => t.ID.ToString())));
          }
      
          Console.WriteLine("\nSuspected members");
          foreach (var key in table.Where(t => suspects.Contains(t.Key)))
          {
              Console.WriteLine("{0} talked to {1}", key.Key, string.Join(", ", key.Value.CoSuspects.Select(t => t.ID.ToString())));
          }
      }
