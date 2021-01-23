    int directContractTicketID;
    if (int.TryParse(listEvent[0].EventTicketID, out directContractTicketID))
    {
        // valid int value, parsed value in directContractTicketID
    }
    else
    {
        //  listEvent[0].EventTicketID contains some non-numeric value
    }
