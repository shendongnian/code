        public int whatSeat;
        Transform TheObject;
    
        positions = TheObject.GetComponent<GetInObject>().PosInObect;
        for (whatSeat = 0; whatSeat < positions.Length; whatSeat++)
        {
            if (positions[whatSeat].isOccupied == false)
            {
                transform.parent = positions[whatSeat].pos;
                positions[whatSeat].isOccupied = true;
                break;   // Adding break here
            }
        }
