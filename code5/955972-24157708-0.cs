    //For all slots
    for (int i = 0; i < tempInt; i++)
    {
        //for all genes
        Gene[] lstGene = InitializeArray<Gene>(lchromeSize);
        for (int ii = 0; ii < lchromeSize; ii++)
        {
            //assign values to local variables 
            // and :
            lstGene[ii].Date = ldate;
            lstGene[ii].Tcode = lteacherCode;                    
            lstGene[ii].Availabe = lavailable;
            lstGene[ii].Duty = tempDuty;
            lstGene[ii].Fitness = 0;
        }
        //End ii For
        //Add the genes to slotsList
        Slot itemtoadd = new Slot(lchromeSize);
        itemtoadd.setChromosomes(lstGene);
        slotsList.Add(itemtoadd);
    }
