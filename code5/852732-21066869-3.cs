    using System;
    using System.Text;
    class SystemInfo
    {
        private string machineName;
        private int freeSpace;
        private int processorCount;
        // Private so no one can create it directly.
        private SystemInfo()
        {
        }
        // This is a static method now.  Call SystemInfo.Encode() to use it.
        public static byte[] Encode()
        {
            // Convert the machine name to an ASCII-based byte array.
            var machineNameAsByteArray = Encoding.ASCII.GetBytes(Environment.MachineName);
            // *THIS IS IMPORTANT*  The easiest way to encode a string value so that it
            // can be easily decoded is to prepend the length of the string.  Otherwise,
            // you're left guessing on the decode side about how long the string is.
            // Calculate the message length.  This does *NOT* include the size of
            // the message length itself.
            // NOTE:  As new fields are added to the message, account for their
            //        respective size here and encode them below.
            var messageLength = sizeof(int)                   + // length of machine name string
                                machineNameAsByteArray.Length + // the machine name value
                                sizeof(int)                   + // free space
                                sizeof(int);                    // processor count
            // Calculate the required size of the byte array.  This *DOES* include
            // the size of the message length.
            var byteArraySize = messageLength + // message itself
                                sizeof(int);    // 4-byte message length field
            // Allocate the byte array.
            var bytes = new byte[byteArraySize];
            // The offset is used to keep track of where the next field should be
            // placed in the byte array.
            var offset = 0;
            // Encode the message length (a very simple header).
            Buffer.BlockCopy(BitConverter.GetBytes(messageLength), 0, bytes, offset, sizeof(int));
            // Increment offset by the number of bytes added to the byte array.
            // Note that the increment is equal to the value of the last parameter
            // in the preceding BlockCopy call.
            offset += sizeof(int);
            // Encode the length of machine name to make it easier to decode.
            Buffer.BlockCopy(BitConverter.GetBytes(machineNameAsByteArray.Length), 0, bytes, offset, sizeof(int));
            // Increment the offset by the number of bytes added.
            offset += sizeof(int);
            // Encode the machine name as an ASCII-based byte array.
            Buffer.BlockCopy(machineNameAsByteArray, 0, bytes, offset, machineNameAsByteArray.Length);
            // Increment the offset.  See the pattern?
            offset += machineNameAsByteArray.Length;
            // Encode the free space.
            Buffer.BlockCopy(BitConverter.GetBytes(GetTotalFreeSpace("C:\\")), 0, bytes, offset, sizeof(int));
            // Increment the offset.
            offset += sizeof(int);
            // Encode the processor count.
            Buffer.BlockCopy(BitConverter.GetBytes(Environment.ProcessorCount), 0, bytes, offset, sizeof(int));
            // No reason to do this, but it completes the pattern.
            offset += sizeof(int).
            return bytes;
        }
        // Static method.  Call is as SystemInfo.Decode(myReceivedByteArray);
        public static SystemInfo Decode(byte[] message)
        {
            // When decoding, the presumption is that your socket code read the first
            // four bytes from the socket to determine the length of the message.  It
            // then allocated a byte array of that size and read the message into that
            // byte array.  So the byte array passed into this function does *NOT* have
            // the 4-byte message length field at the front of it.  It makes no sense
            // in this class anyway.
            // Create the SystemInfo object to be populated and returned.
            var si = new SystemInfo();
            // Use the offset to navigate through the byte array.
            var offset = 0;
            // Extract the length of the machine name string since that is the first
            // field encoded in the message.
            var machineNameLength = BitConverter.ToInt32(message, offset);
            // Increment the offset.
            offset += sizeof(int);
            // Extract the machine name now that we know its length.
            si.machineName = Encoding.ASCII.GetString(message, offset, machineNameLength);
            // Increment the offset.
            offset += machineNameLength;
            // Extract the free space.
            si.freeSpace = BitConverter.ToInt32(message, offset);
            // Increment the offset.
            offset += sizeof(int);
            // Extract the processor count.
            si.processorCount = BitConverter.ToInt32(message, offset);
            // No reason to do this, but it completes the pattern.
            offset += sizeof(int);
            return si;
        }
    }
