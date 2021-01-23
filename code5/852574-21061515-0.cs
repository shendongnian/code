        <script type="text/javascript">
        function IsNoneNumeric(sender, arguments) {
            var NoneNumeric = true;
            for (count = arguments.Value.length; count > 0; count--) {
                TempChar = arguments.Value.substring(count, count + 1);
                if (numString.indexOf(TempChar, 0) != -1) {
                    NoneNumeric = false;
                }
                if (NoneNumeric == true) {
                    arguments.IsValid = true;
                }
                else {
                    arguments.IsValid = false;
                }
            }
        }
    </script>
