    do
            {
                RNG_NXT =RNG +1;   
            for (int iii = 0; iii <Nold -1; iii++)
                        {
                            if ((output[iii] == imax) && (output[iii + 1] == jmax))
                            {
                                output[J] = Convert.ToByte(RNG_NXT);
                                J = J + 1;
                                iii = iii + 1;
                            }
                            else
                            {
                                output[J] = output[iii];
                                J = J + 1;
                            }
                       }
                            
            }
    while( RNG < RNG_MAX) ;
