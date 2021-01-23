     public interface IResetable
     {
          void ResetControl();
     }
.....
     foreach(var control in bodyPanel.Controls)
     {
          var resetable = control as IResetable;
          if (resetable != null)
               resetable.ResetControl();
     }
