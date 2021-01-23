      public string GetCustomerEmail(int id)
      {
          Customer findEmail = new Customer(id);
          for (int i=0; i < customerList.Count;i++)
              if (customerList[i].Equals(findEmail))
                  return customerList[i].CustomerEmail;
          return null;
      }
