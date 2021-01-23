    private void DoAction()
      {
          if (HasData)
          {
              var data = this.ReadValue("data");
          }
          else if (HasId)
          {
              var id = this.ReadValue("id");
          }
      }
    }
