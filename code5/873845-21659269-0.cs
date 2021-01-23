    namespace EcoHelp
    {
        class Kozos_fuggvenyek
        {
            public static void call_nonstatic(Form form)
            {
               //Angol kultúra értékül adása a 'cul' változónak.
               var cul = CultureInfo.CreateSpecificCulture("en-US");
               //Egyes elemek 'Text' tulajdonságainak beállítása a 'Res.en.resx' fájlból.
               form.Text = form.res_man.GetString("Termekek_kezelese_From", cul);
               form.Termek_adatok_Groupbox.Text = form.res_man.GetString("Termek_adatok_Groupbox", cul);
               form.Termekkod_Label.Text = form.res_man.GetString("Termekkod_MIND_Label", cul);
               form.Termeknev_Label.Text = form.res_man.GetString("Termeknev_MIND_Label", cul);
            }
        }
    }
