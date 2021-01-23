    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Beetlegeuse_intrusion
    {
        class Program
        {
            static void Main(string[] args)
            { 
                Init();
            }
            static void Init()
            {
                weapon testWeapon = new weapon(30, 50);
                weapon[] weaponArray1 = new weapon[3];
                for(int i=0; i<2; i++)
                weaponArray1[i] = testWeapon;
            }
        }    
    }
