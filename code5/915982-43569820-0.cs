    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Popups;
    
    namespace someApp.ViewModels
    {
        public static class Msgbox
        {
            static public async void Show(string mytext)
            {
                var dialog = new MessageDialog(mytext, "Testmessage");
                await dialog.ShowAsync();
            }
        }
    
    }
