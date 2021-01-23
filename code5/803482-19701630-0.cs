        class Item{
          public string algorithm {get;set;}
          public float amount {get;set;}
          public string currency {get;set;}
          public Date issued_at {get;set;}
          public string payment_id {get;set;}
          public int quantity {get; set;}
          public string status {get;set;}
        }
       Item item = JSON.Deserialaize(JSON_OBJECT)  // check for specific syntax
       Item[] item = JSON.Deserialize(JSON_OBJECT) // even can get array of json objects
