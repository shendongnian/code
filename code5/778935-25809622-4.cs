          public void OnSelectedItem(Item item)
         {
                SessionInfo.Instance.eventHanlder.GetEvent<Notification>().Publish(item.id);
            
          }
