    //Now I am checking to see if a bullet has hit an alien. Use of the For loop again.
            if (ShipBulletVisible.Equals("Yes"))
            {
                for (int i = 0; i < rectSpaceInvader.Length; i++)
                {
                    if (AlienAlive[i].Equals("Yes"))
                    {
                        if (...)
                        for (int i = 0; i < rectSpaceInvader.Length; i++)<-- this is causing the error. Change the variable to x or j like was suggested, or change the outer loops variable
                        {...}
                        //Now we will check to see if the aliens reach the bottom of the screen and hit our ship which would cause a game over.
                        for (int i = 0; i < rectSpaceInvader.Length; i++)<-- same thing here
                        {...}
                    }
                }
            }
