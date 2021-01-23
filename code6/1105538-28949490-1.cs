     private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new EDMmanytomanyContainer())
            {                
              var result = context.MOrdens
                                  .Where(s => s.Mdistributors.Any(c=> c.Nombre=="DVerdesoto"))
                                  .SelectMany(mo => mo.Mproductos);                                                                     
            }
        }
