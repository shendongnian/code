    // Allocate positions 
        for (var i = 0; i < bidList.Count; i++)
        {
            var position = i + 1;
            bidList[i].Position = position;
            query = "UPDATE bid SET position='" + position + "' WHERE operator_id='" + bidList[i].OperatorId +
                        "'";
            var dbObject = new DbConnect();
            dbObject.InsertBooking(query);
        }
        return bidList.OrderBy(bid => bid.Position);
