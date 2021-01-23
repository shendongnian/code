            @model System.Data.Entity.DbSet<NotesExample.Models.Note>
            @{
                MyDbContext context = new MyDbContext();
                int noteCount = Model.Count();
                var notes = Model.ToList();
            }
            @for (int i = 0; i < noteCount || (notes.Count == 0 && i == 0); ++i)
            {
                if (notes.Count == 0 || i == notes.Count - 1)
                {
                    //Add New Note
                    Html.RenderPartial("NewNote", new NotesExample.Models.Note());
                }
                else
                {
                    //Render Exising Notes
                    var note = notes[i];
                    <div>
                        <h3>Note ID: @note.Id</h3>
                        <h3>Text: @note.Text</h3>
                        <h3>Time (ticks): @note.Time</h3>
                    </div>
                }
            }
    
