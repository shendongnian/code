    var data = (@"1i11A0014092414220&&");
    const string checkSum = "FBEA";
    // Checksum is 16 bit word
    var checkSumValue = Convert.ToUInt16(checkSum, 16);
    // Sum of message chars preceeding checksum
    var mySum = data.Sum<char>(c => c);
    var validate = (UInt16)( checkSumValue + mySum);
    Console.WriteLine("Data: {0}", data);
    Console.WriteLine("Checksum: {0:X4}", checkSumValue);
    Console.WriteLine("Sum of chars: {0:X4}", mySum);
    Console.WriteLine("Validation: {0}", Convert.ToString(validate, 2));
    Console.ReadKey();
