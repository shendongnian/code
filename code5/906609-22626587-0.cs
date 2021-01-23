            if (GenderOption ==1){
                if (WaistToHeightRatio >= 0.536) {
                    Console.WriteLine("Your Risk of Obesity Related Cardiovascular Diseases is at High Risk");
                } 
                else {
                    Console.WriteLine("Your Risk of Obesity Related Cardiovascular Diseases is at low Risk");
                }
            } 
            else 
                if (GenderOption == 2) {
                    if (WaistToHeightRatio >= 0.492) {
                        Console.Write("Your Risk of Obesity Related Cardiovascular Diseases is at High Risk");
                    } 
                    else {
                        Console.Write("Your Risk of Obesity Related Cardiovascular Diseases is at low Risk");
                    }
                }
