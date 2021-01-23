    InventoryAssignment assignment = new InventoryAssignment
    {
        issueInventoryNumber = new RecordRef { internalId = 'internalID',
        type = 'RecordType',
        typeSpecified = true 
        }
    };
    List<InventoryAssignment> list = new List<InventoryAssignment>();
                                        
    list.Add(assignment);
    ifitemlist.item[b].inventoryDetail = new InventoryDetail
    {
         inventoryAssignmentList = new InventoryAssignmentList
         {
             inventoryAssignment = list.ToArray()
         }
    };
    ifitemlist.item[b].quantity += 'quantity shipped';
