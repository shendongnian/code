    if (ScrollPosition < 5)
            {
                acorde = "A";
                lblnota.Text = "A/La";
                lblnota2.Text = "A/La";
                imagen.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\A.jpg");
            if(note != 1)
            {
                lblnote.Text = "A";
                lblcuerda.Text = "5° cuerda";
                lbltraste.Text = "";
                imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\MAL.jpg");
            }
            else if(note != 8)
            {
                lblnote.Text = "E";
                lblcuerda.Text = "4° cuerda";
                lbltraste.Text = "2° traste";
                imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\MAL.jpg");
            }
            else if(note != 1)
            {
                lblnote.Text = "A";
                lblcuerda.Text = "3° cuerda";
                lbltraste.Text = "2° traste";
                imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\MAL.jpg");
            }
            else if(note != 5)
            {
                lblnote.Text = "C#";
                lblcuerda.Text = "2° cuerda";
                lbltraste.Text = "2° traste";
                imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\MAL.jpg");
            }
            else if(note != 8)
            {
                lblnote.Text = "E";
                lblcuerda.Text = "1° cuerda";
                lbltraste.Text = "";
                imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\MAL.jpg");
            }
            imagenok.Image = Image.FromFile(@"C:\Users\Sebastian\Desktop\GuitarraFINAL\Guitarist\Imagenes\OK.jpg");
        }
