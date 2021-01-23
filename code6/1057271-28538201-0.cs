    if (AspNetCryptoServiceProvider.Instance.IsDefaultProvider) {
                // ASP.NET 4.5 Crypto DCR: Go through the new AspNetCryptoServiceProvider
                // if we're configured to do so.
                ICryptoService cryptoService = AspNetCryptoServiceProvider.Instance.GetCryptoService(purpose, CryptoServiceOptions.CacheableOutput);
                clearData = cryptoService.Unprotect(protectedData);
            }
            else {
                // If we're not configured to go through the new crypto routines,
                // fall back to the standard MachineKey crypto routines.
    #pragma warning disable 618 // calling obsolete methods
                clearData = MachineKeySection.EncryptOrDecryptData(fEncrypt: false, buf: protectedData, modifier: null, start: 0, length: protectedData.Length, useValidationSymAlgo: false, useLegacyMode: false, ivType: IVType.Hash);
    #pragma warning restore 618 // calling obsolete methods
            } 
