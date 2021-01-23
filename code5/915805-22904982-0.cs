    userList.ForEach(o =>
        {
            var result = o.ConnectionIds.Except(c => c.ID == "idToBeRemoved");
        }
    );
