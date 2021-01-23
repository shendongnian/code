    foreach (var item in listOfItems.Select(i => i.Item).Where(item => item != null))
            {
                if (item.LocationCode == null){
                  continue;
                }
                var instance = new SomeClass();         
                if (pickUpCode != null)
                {
                    instance.PickUpCode = pickUpCode;
                }
                else
                {               
                    instance.PickUpCode = null;
                }
                // if we reach here, location code is definitley not null, no need for the check            
                instance.StartLocation = locationCode
                
               
                repository.SaveSomeClass(instance);
            }
