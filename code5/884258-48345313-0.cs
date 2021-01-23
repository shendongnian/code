     TextRange Mytextrange2;
     private void Selectline(int line)
        {
            // STEP1: set CaretPosition to fist position of richtextbox (Vietnamese: đưa Carretposition về vị trí đầu của richtextbox)
            TextPointer resetpos = richTextBox.Document.ContentStart;	
            richTextBox.CaretPosition = resetpos;
            // STEP2: get start Position of your line and get startpos of your line +1 (mean end positon of your need line) (Vietnammes: Lấy vị trí đầu và cuối của line)
            TextPointer startPos = richTextBox.CaretPosition.GetLineStartPosition(line);
            TextPointer endPos = richTextBox.CaretPosition.GetLineStartPosition(line + 1);
            // STEP3: return if Error
            if (startPos == null) return;
            if (endPos == null) return;
            // STEP4: Clear properties of your previous line (i'm highlighting line by line of richtextbox, so i need to clear properties of previous line before apply new properties to next line)
	// Xóa các thuộc tính áp dụng cho dòng trước, vì tôi bôi đen từng dòng trong richtextbox nên khi bôi đen dòng này tôi sẽ bỏ bôi đen dòng trước kia đi
            if (line != 0) // in this case, i clear properties when line != 0, ofcoursce you can change it (trong trường hợp dòng 0, tôi không xóa dòng trước vì trước nó không có dòng nào cả)
            {
                Mytextrange2.ClearAllProperties(); 
                //Mytextrange2.ApplyPropertyValue(TextElement.BackgroundProperty,Brushes.DarkGray);
                Mytextrange2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DarkGray);
            }
            // STEP5: Select new textrang and apply new properties to your new line // Dùng textrange để chọn dòng cần bôi đen, sau đó add các thuộc tính vào
            Mytextrange2.Select(startPos, endPos); // select range of text to apply new properties
            Mytextrange2.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);  
            Mytextrange2.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.DarkGray);
            Mytextrange2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            // STEP6: scroll richtextbox to next 14th line to make reasonable view (if imposible). // scroll đến 14 dòng sau dòng được chọn, để dòng được chọn ở giữa khung màn hình, bạn có thể chọn dòng khác
            richTextBox.CaretPosition = startPos; // Set CaretPosition to selected line
            startPos = richTextBox.CaretPosition.GetLineStartPosition(14); //(find position of next 14th line to scroll ) Change value 14 to have more reasonable view
            if (startPos != null)  richTextBox.CaretPosition = startPos;   // Set caretposition to position of next 14 lines
            richTextBox.Focus();   // scroll richtextbox to caretposition
        }
      private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Mytextrange2 là biến toàn cục muốn dùng để thực hiện xóa properties của dòng trước, nên tôi phải khởi tạo ở 1 chỗ khác ngoài hàm Selectline
 	// Initialize Mytextrang2
            Mytextrange2 = new TextRange(richTextBox.Document.ContentStart,richTextBox.Document.ContentEnd);
        }
