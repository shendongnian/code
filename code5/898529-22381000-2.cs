		byte[] text = <put here bytes captured from StandardOut of child process>
		foreach(System.Text.EncodingInfo encodingInfo in System.Text.Encoding.GetEncodings())
		{
			System.Text.Encoding encoding = encodingInfo.GetEncoding();
			string decodedBytes = encoding.GetString(bytes);
			System.Console.Out.WriteLine("Encoding: {0}, Decoded Bytes: {1}", encoding.EncodingName, decodedBytes);
		}
