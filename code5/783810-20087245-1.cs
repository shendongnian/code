    [StructLayout(LayoutKind.Sequential,Pack=1)]
    unsafe struct UserGroup{
        fixed char name[12];
        fixed byte users[512 * Constants.SizeOfUser]
        int somethingElse;
        fixed char anotherThing[16];
		public User[] Users
		{
			get
			{
				var retArr = new User[512];
				fixed(User* retArrRef = retArr){
					fixed(byte* usersFixed = users){
						{
							Memory.Copy(usersFixed, retArrRef,  512 * Constants.SizeOfUser);
						}
					}
				}
				return retArr;
			}
		}
    }
