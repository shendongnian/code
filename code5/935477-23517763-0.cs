       private Nullable<bool> IsOffice64Bit(string RegistryPrefix, string OfficeVersionNo)
        {
            Nullable<bool> isOffice64Bit = null;
            string Bitness = GetRegKey64(HKEY_LOCAL_MACHINE, RegistryPrefix + OfficeVersionNo + "\\Outlook", "Bitness");
            if (Bitness == "x86")
                isOffice64Bit = false;
            else if ((Bitness == "x64"))
                isOffice64Bit = true;
            return isOffice64Bit;
        }
