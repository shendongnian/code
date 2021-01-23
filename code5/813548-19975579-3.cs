      private bool _coercing = false;
      private void CoerceSubitem()
      {
          if (_coercing)
              return;
          try
          {
              _coercing = true;
              if (!PossibleSubitems.Contains(CurrentSubitem))
              {
                  CurrentSubitem = PossibleSubitems[0];
              }
          }
          finally
          {
              _coercing = false;
          }
      }
