    sealed class Weapon {
       public string Name { get; set; }
    }
    sealed class Character {
       const int sSkillToUseWeapon = 50;
       readonly Dictionary<string, int> mWeaponSkills = new Dictionary<string, int>();
       Weapon mCurrentWeapon;
       public Weapon CurrentWeapon {
          get {
             return mCurrentWeapon;
          } set {
             if (!mWeaponSkills.ContainsKey(value.Name))
                return;
             if (mWeaponSkills[value.Name] < mSkillToUseWeapon)
                return;
             mCurrentWeapon = value;
          }
       }
       public void SetWeaponSkill(string pWeaponName, int pSkill) {
          if (mWeaponSkills.ContainsKey(pWeaponName))
             mWeaponSkills[pWeaponName] = pSkill;
          else
             mWeaponSkill.Add(pWeaponName, pSkill);
       }
    }
