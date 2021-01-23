    // ---------------------------------------------------------------------------------------------------------------------
    // <copyright file="NModbusDeviceConnection.cs" company="Care Controls">
    //   Copyright (c) Care Controls Inc. All rights reserved.
    // </copyright>
    // ---------------------------------------------------------------------------------------------------------------------
    namespace CareControls.Modbus.Tcp.Internal
    {
        using System;
        using System.Net.Sockets;
        using System.Reflection;
        using global::Modbus.Device;
        internal sealed class NModbusDeviceConnection : IDisposable
        {
            static NModbusDeviceConnection()
            {
                AppDomain.CurrentDomain.AssemblyResolve += (sender, e) => loadEmbeddedAssembly(e.Name);
            }
            public NModbusDeviceConnection(string ip)
            {
                const int port = 502;
                var client = new TcpClient();
                client.BeginConnect(ip, port, null, null).AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
                if (!client.Connected)
                {
                    throw new Exception("Cannot connect to " + ip + ":" + port);
                }
                this.connection = ModbusIpMaster.CreateIp(client);
            }
            public ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfRegisters)
            {
                return this.connection.ReadHoldingRegisters(startAddress, numberOfRegisters);
            }
            public ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfRegisters)
            {
                return this.connection.ReadInputRegisters(startAddress, numberOfRegisters);
            }
            public bool[] ReadCoils(ushort startAddress, ushort numberOfCoils)
            {
                return this.connection.ReadCoils(startAddress, numberOfCoils);
            }
            public bool[] ReadInputs(ushort startAddress, ushort numberOfInputs)
            {
                return this.connection.ReadInputs(startAddress, numberOfInputs);
            }
            public void WriteSingleCoil(ushort address, bool value)
            {
                this.connection.WriteSingleCoil(address, value);
            }
            public void WriteMultipleCoils(ushort startAddress, bool[] values)
            {
                this.connection.WriteMultipleCoils(startAddress, values);
            }
            public void WriteSingleHoldingRegister(ushort address, ushort value)
            {
                this.connection.WriteSingleRegister(address, value);
            }
            public void WriteMultipleHoldingRegisters(ushort address, ushort[] values)
            {
                this.connection.WriteMultipleRegisters(address, values);
            }
            public void Dispose()
            {
                if (this.connection != null)
                {
                    this.connection.Dispose();
                }
            }
            private static Assembly loadEmbeddedAssembly(string name)
            {
                if (name.EndsWith("Retargetable=Yes"))
                {
                    return Assembly.Load(new AssemblyName(name));
                }
                var container = Assembly.GetExecutingAssembly();
                var path = new AssemblyName(name).Name + ".dll";
                using (var stream = container.GetManifestResourceStream(path))
                {
                    if (stream == null)
                    {
                        return null;
                    }
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    return Assembly.Load(bytes);
                }
            }
            private readonly ModbusIpMaster connection;
        }
    }
