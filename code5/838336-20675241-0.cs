    void Update ()
    {
        if (fwdi > 0)
        {
            amountToMove.y = 0.1f*Time.deltaTime;
            transform.Translate (amountToMove);
            fwdi = fwdi - amountToMove.y;
            //This code bellow looks redundant, and probably unnecessary
            if (fwdi == 0)
            {
                amountToMove.y = 0;
                fwdi = 0f;
            }
        }
    }
