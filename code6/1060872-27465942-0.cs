    static public DialogResult ShowDialog(string title, string largeHeading, string smallExplanation, string leftButton, string rightButton, Image iconSet, ref int variavelcaixa)
---
    DialogResult result = BetterDialog.ShowDialog("Alert",
      "Warning message 1",
      "some consequences in a string",
      "Do action button", "Cancel button", System.Drawing.Bitmap.FromFile(icone),
       ref variableofthismessagebox);
